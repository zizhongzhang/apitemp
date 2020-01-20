using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Client
{
    public abstract class ApiResponse
    {
        protected ApiResponse(int statusCode)
        {
            StatusCode = statusCode;
        }

        protected ApiResponse(int statusCode, IDictionary<string, IEnumerable<string>> errors)
        {
            if (errors == null || errors.Count == 0)
            {
                throw new ArgumentNullException(nameof(Errors));
            }

            if (statusCode >= 200 && statusCode <= 299)
            {
                throw new ArgumentOutOfRangeException(nameof(StatusCode));
            }

            StatusCode = statusCode;
            Errors = errors;
        }

        public int StatusCode { get; }
        protected IDictionary<string, IEnumerable<string>> Errors { get; } = new Dictionary<string, IEnumerable<string>>();
        public bool IsSuccessful => Errors.Count > 0;
    }

    public class ApiResponse<T> : ApiResponse where T : class, new()
    {
        protected ApiResponse(int statusCode) : base(statusCode)
        {
        }

        protected ApiResponse(int statusCode, IDictionary<string, IEnumerable<string>> errors) : base(statusCode, errors)
        {

        }

        protected ApiResponse(T data) : base(200)
        {
            Data = data;
        }

        public T Data { get; }

        public static readonly ApiResponse<T> Unauthorized = new ApiResponse<T>(401);
        public static readonly ApiResponse<T> NotFound = new ApiResponse<T>(404);
        public static readonly ApiResponse<T> Conflict = new ApiResponse<T>(409);
    }


    public class OrganisationResponse : ApiResponse<Organisation>
    {
        public OrganisationResponse(Organisation data) : base(data)
        {
        }

        public OrganisationResponse(int statusCode, IDictionary<string, IEnumerable<string>> errors) : base(statusCode, errors)
        {
        }
        public static readonly OrganisationResponse Unauthorized = ApiResponse<Organisation>.Unauthorized;
    }

    public class HttpClient
    {
        public OrganisationResponse GetOrganisationResponse()
        {
            var response = new HttpResponseMessage();
            if (response.IsSuccessStatusCode)
            {
                return new OrganisationResponse(new Organisation());
            }
            return ApiResponse<Organisation>.Unauthorized;
        }
    }

}
