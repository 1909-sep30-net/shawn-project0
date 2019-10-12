using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class HistoryHandler
    {
        public Dictionary<string, Dictionary<string, string>> Database { get; set; }
        public string TargetId { get; set; }
        public string RetrievalType { get; set; }

        public void GetHistory()
        {
            var HistoryMatchList = new List<Dictionary<string, string>>();
            foreach (var record in Database)

                if (record.Value[RetrievalType] == TargetId)
                {
                    HistoryMatchList.Add(record.Value);
                }

            MessageHandler.ShowOrderHistory(HistoryMatchList, RetrievalType, TargetId);
        }
    }
}
