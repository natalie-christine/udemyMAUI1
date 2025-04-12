using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class SupabaseViewModel : ObservableObject
    {
        private readonly Supabase.Client client;
        private Supabase.Gotrue.Session? session;

        [ObservableProperty]
        private string loginUsername = "";
        [ObservableProperty]
        private string loginPassword = "";

        [ObservableProperty]
        private bool isLoggedIn = false;
        [ObservableProperty]
        private string? errorMessage = null;
        [ObservableProperty]
        private Supabase.Gotrue.User? user = null;
        [ObservableProperty]
        private List<Todo>? todos = null;

        [ObservableProperty]
        private Todo? newTodo = new Todo();

        public SupabaseViewModel(Supabase.Client _client)
        {
            client = _client;
        }

        public async Task Init()
        {
            client.Auth.LoadSession();
            session = await client.Auth.RetrieveSessionAsync();
            if (session != null)
            {
                LoadTodosCommand.Execute(null);
            }
            UpdateStatus();
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

        public ICommand SaveNewTodoCommand => new Command(async () => {
            if (NewTodo != null)
            {
                NewTodo.Done = false;
                NewTodo.UserId = session.User.Id;
                await client.From<Todo>().Insert(NewTodo);
                NewTodo = new Todo();

                LoadTodosCommand.Execute(null);
            }
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
