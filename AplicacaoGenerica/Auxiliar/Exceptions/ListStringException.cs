using System;
using System.Collections.Generic;

namespace basecs.Auxiliar.Exceptions {
    public class ListStringException : Exception {
        public List<Exception> TaskExceptions { get; set; }
        public ListStringException () {
            TaskExceptions = new List<Exception> ();
        }
    }
}