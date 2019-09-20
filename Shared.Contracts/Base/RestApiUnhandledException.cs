using Shared.Core.Extension;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shared.Contracts.Base
{
    public class RestApiUnhandledException : Exception, ISerializable
    {
        public RestApiUnhandledException() { }

        private string _uniqueId { get; set; }

        public string UniqueId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_uniqueId))
                {
                    _uniqueId = ExceptionHelper.GenerateUniqueId();
                }
                return _uniqueId;
            }
            set { _uniqueId = value; }
        }

        public RestApiUnhandledException(string message, Exception inner) : base(message, inner)
        { }
        public RestApiUnhandledException(string message) : base(message) { }

        public RestApiUnhandledException(Exception inner) : base(null, inner) { }

        public override string Message => $"Error Id :{UniqueId} {base.Message}".TrimEnd();

        protected RestApiUnhandledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            UniqueId = info.GetString("UniqueId");
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("UniqueId", UniqueId);
        }
    }
}
