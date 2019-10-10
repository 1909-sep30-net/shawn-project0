using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class HistoryHandler
    {
        public Dictionary<string, Dictionary<string, string>> Database { get; set; }
        public string TargetId { get; set; }
        public string RetrievalType { get; set; }

        public void GetHistory()
        {
            foreach (var record in Database)
            {
                if (record.Value[RetrievalType] == TargetId)
                {
                    MessageHandler.ShowOrderHistory(record.Value);
                }

            }
        }
    }
}
