using AngularUnits.Provider.IAngularUnit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Geolocation.Api.Unity.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/geolocation")]
    public class GeolocationController : ApiController
    {
        private readonly IGeolocationOperator _operator;
        public GeolocationController(IGeolocationOperator provider)
        {
            _operator = provider;
        }

        [HttpGet]
        [Route("getradian/{degree:string}")]
        public IHttpActionResult GetRadian(string degree) => Ok(new { Degree = degree, Radian = _operator.DegreesToRadians(degree) });

        [HttpGet]
        [Route("getdegree/{radian:string}")]
        public IHttpActionResult GetDegree(string radian) => Ok(new { Radian = radian, Degree = _operator.RadiansToDegrees(radian) });


        [HttpGet]
        [Route("DegreesToCardinal/{degree:double}")]
        public IHttpActionResult DegreesToCardinal(double degree) => Ok(new { Radian = degree, Cardinal = _operator.DegreesToCardinal(degree) });

        
        [HttpGet]
        [Route("gradtoradian/{grad:double}")]
        public HttpResponseMessage GradToRadian(double grad)
        {
            try
            {
                var result = _operator.GradsToRadians(grad);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("radiantograd/{radian:double}")]
        public HttpResponseMessage RadianToGrad(double radian)
        {
            try
            {
                var result = _operator.RadiansToGrads(radian);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("degreestograd/{degree:double}")]
        public HttpResponseMessage DegreesToGrad(double degree)
        {
            try
            {
                var result = _operator.DegreesToGrads(degree);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("gradtodegree/{grad:double}")]
        public HttpResponseMessage GradToDegree(double grad)
        {
            try
            {
                var result = _operator.GradsToDegrees(grad);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("tosec/{x:double}")]
        public HttpResponseMessage ToSec(double x)
        {
            try
            {
                var result = _operator.Sec(x);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("tocosec/{x:double}")]
        public HttpResponseMessage ToCoSec(double x)
        {
            try
            {
                var result = _operator.Csc(x);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("tocot/{x:double}")]
        public HttpResponseMessage ToCot(double x)
        {
            try
            {
                var result = _operator.Cot(x);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getdirection/{x1:int}/{y1:int}/{x2:int}/{y2:int}")]
        public HttpResponseMessage GetDirection(int x1,int y1,int x2, int y2)
        {
            try
            {
                Point start = new Point(x1,y1);
                Point end = new Point(x2,y2);
                var result = _operator.GetDirection(start,end);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
