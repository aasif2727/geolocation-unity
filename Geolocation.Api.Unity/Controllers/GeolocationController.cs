using Geolocation.Api.Unity.Provider;
using Geolocation.Api.Unity.Provider.IFactory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using Geolocation.Api.Unity.Models;

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

        /// <summary>
        /// http://localhost:34006/api/geolocation/getradian/10
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getradian/{degree:double}")]
        public IHttpActionResult GetRadian(double degree) => Ok(new { Degree = degree, Radian = _operator.DegreesToRadians(degree) });

        /// <summary>
        /// http://localhost:34006/api/geolocation/getdegree/10
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getdegree/{radian:double}")]
        public IHttpActionResult GetDegree(double radian) => Ok(new { Radian = radian, Degree = _operator.RadiansToDegrees(radian) });

      
        /// <summary>
        /// http://localhost:34006/api/geolocation/gradtoradian/10
        /// </summary>
        /// <param name="grad"></param>
        /// <returns></returns>
        [HttpGet]        [Route("gradtoradian/{grad:double}")]
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

        /// <summary>
        /// http://localhost:34006/api/geolocation/radiantograd/10
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
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

        /// <summary>
        /// http://localhost:34006/api/geolocation/degreestograd/10
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
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

        /// <summary>
        /// http://localhost:34006/api/geolocation/gradtodegree/10
        /// </summary>
        /// <param name="grad"></param>
        /// <returns></returns>
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

        /// <summary>
        /// http://localhost:34006/api/geolocation/tosec/10
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
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

        /// <summary>
        /// http://localhost:34006/api/geolocation/tocosec/10
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
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

        /// <summary>
        /// http://localhost:34006/api/geolocation/tocot/10
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
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

        /// <summary>
        /// http://localhost:34006/api/geolocation/getdirection/10/11/43/44
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
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
