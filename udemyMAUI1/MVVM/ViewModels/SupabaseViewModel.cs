using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using udemyMAUI1.Models.DB;

namespace udemyMAUI1.MVVM.ViewModels
{
    public partial class SupabaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly Supabase.Client client;
        private Supabase.Gotrue.Session? session;

        private bool isLoggedIn = false;
        public bool IsLoggedIn { get { return isLoggedIn; } set { isLoggedIn = value; NotifyPropertyChanged(); } }

        private string? errorMessage = null;
        public string? ErrorMessage { get { return errorMessage; } set { errorMessage = value; NotifyPropertyChanged(); } }

        private Supabase.Gotrue.User? user = null;
        public Supabase.Gotrue.User? User { get { return user; } set { user = value; NotifyPropertyChanged(); } }

        private List<Todo>? todos = null;
        public List<Todo>? Todos { get { return todos; } set { todos = value; NotifyPropertyChanged(); } }

        public SupabaseViewModel(Supabase.Client client)
        {
            this.client = client;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LogIn(string username, string password)
        {
            ErrorMessage = null;
            try
            {
                session = await client.Auth.SignIn(username, password);
            }
            catch (Supabase.Gotrue.Exceptions.GotrueException ex)
            {
                ErrorMessage = ex.Message;
                ErrorMessage = ex.Reason.ToString();
            }
            UpdateStatus();
        }

        public async Task LogOut()
        {
            ErrorMessage = null;
            await client.Auth.SignOut();
            session = null;
            UpdateStatus();
        }

        public async Task LoadTodos()
        {
            Todos = null;
            var results = await client.From<Todo>().Get();
            await  client.From<Todo>().Where(x => x.UserId == session!.User!.Id).Get();
            Todos = results.Models;
        }

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
