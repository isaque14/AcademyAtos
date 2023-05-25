namespace Parking.Services.baseResponses
{
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string StatusMessage { get; set; }
    }
}
