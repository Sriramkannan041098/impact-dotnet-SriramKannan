using System;
using System.Collections.Generic;
using System.Text;

namespace A4_ModelViewController.Service
{
    public class TransactionLog
    {
        private readonly List<string> _history = new List<string>();

        public void AddEntry(string message)
        {
            _history.Add( $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}" );
        }

        public List<string> GetHistory()
        {
            return new List<string>(_history);
        }
    }
}
