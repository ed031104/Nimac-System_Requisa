using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.data
{
    public class ServiceResponse<T>
    {
        private T? _data;
        private string _message;
        private bool _success;
        private string _errorMessage;

        #region constructors
        public ServiceResponse()
        {
            _data = default(T);
            _message = string.Empty;
            _success = true;
            _errorMessage = null;
        }

        public ServiceResponse(T data, string message, bool success, string errorMessage = null)
        {
            _data = data;
            _message = message;
            _success = success;
            _errorMessage = errorMessage;
        }

        #endregion

        public T? Data { get => _data; set => _data = value; }
        public string Message { get => _message; set => _message = value; }
        public bool Success { get => _success; set => _success = value; }
        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly ServiceResponse<T> _response;
            public Builder()
            {
                _response = new ServiceResponse<T>();
            }
            public Builder SetData(T data)
            {
                _response._data = data;
                return this;
            }
            public Builder SetMessage(string message)
            {
                _response._message = message;
                return this;
            }
            public Builder SetSuccess(bool success)
            {
                _response._success = success;
                return this;
            }
            public Builder SetErrorMessage(string errorMessage)
            {
                _response._errorMessage = errorMessage;
                return this;
            }
            public ServiceResponse<T> Build()
            {
                return _response;
            }
        }
        #endregion
    }
}
