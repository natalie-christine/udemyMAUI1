using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;

namespace udemyMAUI1.Helper
{
    internal class SupabaseSessionHandler : IGotrueSessionPersistence<Session>
    {
        private Session? session;

        void IGotrueSessionPersistence<Session>.DestroySession()
        {
            session = null;
        }

        Session? IGotrueSessionPersistence<Session>.LoadSession()
        {
            return session;
        }

        void IGotrueSessionPersistence<Session>.SaveSession(Session _session)
        {
            session = _session;
        }
    }
}