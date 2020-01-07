using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Parameters
{
    public static class DomainParameters
    {
        public const string MethodGET = "GET";
        public const string MethodPUT = "PUT";
        public const string MethodPOST = "POST";
        public const string MethodDELETE = "DELETE";

        public const string TableLoanName = "loans";
        public const string TablePeopleName = "peoples";
        public const string TableBookName = "books";
        public const string TableAddressName = "addresses";
        public const string TableLoanBooksName = "loan_books";

        public const string Borrowed = "Emprestado";
        public const string PartiallyReturned = "Parcialmente devolvido";
        public const string Returned = "Devolvido";


        public const string ColumnVarcharOf8 = "varchar(8)";
        public const string ColumnVarcharOf20 = "varchar(20)";
        public const string ColumnVarcharOf100 = "varchar(100)";
        public const string ColumnVarcharOf11 = "varchar(11)";
        public const string ColumnVarcharOf200 = "varchar(8)";
        public const string ColumnVarcharOf50 = "varchar(8)";

        public const int LengthSize8 = 8;
        public const int LengthSize2 = 2;
        public const int LengthSize11 = 11;
        public const int LengthSize50 = 50;
        public const int LengthSize200 = 200;
        public const int LengthSize100 = 100;
    }
}
