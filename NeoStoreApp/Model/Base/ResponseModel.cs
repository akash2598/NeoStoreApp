using System;
using System.Collections.Generic;
using System.Text;

namespace NeoStoreApp.Model.Base
{
   public class ResponseModel<T>
    {
        public int status;
        public string message;
        public string user_msg;
        public T data;
    }
}
