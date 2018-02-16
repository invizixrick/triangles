using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Triangles.Controllers
{
    public class TrianglesController : ApiController
    {
        public Coordinates GetCoordinates(string row, int column)
        {
            //row.length == 1
            if (row.Length != 1) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (column < 1 || column > 12) throw new HttpResponseException(HttpStatusCode.BadRequest);

            Coordinates coordinates = new Coordinates();

            bool colOdd = (column % 2) > 0;
            int rowNum = ((int)Convert.ToChar(row.ToUpper())) - 64;

            coordinates.v2x = (((column + 1) / 2) * 10) - 10;
            coordinates.v2y = (rowNum - 1) * 10;
            coordinates.v3x = coordinates.v2x + 10;
            coordinates.v3y = coordinates.v2y + 10;
            coordinates.v1x = colOdd ? coordinates.v2x : coordinates.v3x;
            coordinates.v1y = colOdd ? coordinates.v3y : coordinates.v2y;

            return coordinates;
        }
        public Triangle GetTriangle(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            if (v1x < 0 || v1x > 60) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (v1y < 0 || v1x > 60) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (v2x < 0 || v2x > 60) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (v2y < 0 || v2y > 60) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (v3x < 0 || v3x > 60) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (v3y < 0 || v3y > 60) throw new HttpResponseException(HttpStatusCode.BadRequest);
            //todo: misc other checks

            Triangle triangle = new Triangle();

            triangle.row = (Convert.ToChar((v3y / 10) + 64)).ToString();

            triangle.column = (((v3x - 10) / 10) * 2) + 1;
            if (v1x > v2x) triangle.column++;

            return triangle;
        }

    }
    public class Coordinates
    {
        public int v1x;
        public int v1y;
        public int v2x;
        public int v2y;
        public int v3x;
        public int v3y;
    }
    public class Triangle
    {
        public string row;
        public int column;
    }
}
