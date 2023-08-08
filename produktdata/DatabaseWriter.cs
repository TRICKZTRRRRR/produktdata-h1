using System;

namespace produktdata
{
    internal class DatabaseWriter
    {
        private string connectionString;

        public DatabaseWriter(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void InsertData(string producentNavn, string producentAdresse)
        {
            throw new NotImplementedException();
        }
    }
}