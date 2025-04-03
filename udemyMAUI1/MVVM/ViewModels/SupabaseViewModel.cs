using PropertyChanged;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using udemyMAUI1.Models.DB;

namespace udemyMAUI1.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class SupabaseViewModel
    {
        private readonly Supabase.Client client;
        private Supabase.Gotrue.Session? session;

        public string LoginUsername { get; set; } = "";
        public string LoginPassword { get; set; } = "";

        public bool IsLoggedIn { get; set; } = false;
        public string? ErrorMessage { get; set; } = null;
        public Supabase.Gotrue.User? User { get; set; } = null;
        public List<Todo>? Todos { get; set; } = null;

        public SupabaseViewModel(Supabase.Client client)
        {
            this.client = client;
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            ErrorMessage = null;
            try
            {
                session = await client.Auth.SignIn(LoginUsername, LoginPassword);
                LoadTodosCommand.Execute(null);
            }
            catch (Supabase.Gotrue.Exceptions.GotrueException ex)
            {
                //ErrorMessage = ex.Message;
                ErrorMessage = ex.Reason.ToString();
            }
            UpdateStatus();
        });

        public ICommand LogoutCommand => new Command(async () =>
        {
            ErrorMessage = null;
            await client.Auth.SignOut();
            session = null;
            UpdateStatus();
        });

        public ICommand LoadTodosCommand => new Command(async () =>
        {
            Todos = null;
            var results = await client.From<Todo>().Get();
            await client.From<Todo>().Where(x => x.UserId == session!.User!.Id).Get();
            Todos = results.Models;
        });

        private void UpdateStatus()
        {
            if (session != null)
            {
                IsLoggedIn = true;
                User = session.User;
            }
            else
            {
                IsLoggedIn = false;
                User = null;
            }
            Todos = null;
        }
    }
}
