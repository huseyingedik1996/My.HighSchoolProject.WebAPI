using Common.My.HighSchoolProject.WebAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.My.HighSchoolProject.WebAPI.ResponseInterface
{
    public interface IResponse
    {
        string Message { get; set; }

        ResponseType ResponseType { get; set; }
    }
}
