using Project.Domain.Interfaces.Arguments;

namespace Project.Domain.Arguments.Base
{
    public class ResponseBase : IResponse
    {
        public ResponseBase(string message = "Operação realizada com sucesso.")
        {
            Message = message;
        }

        public string Message { get; set; }

        public string Id { get; set; }
    }
}
