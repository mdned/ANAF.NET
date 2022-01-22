using System;

namespace ANAF.NET
{
    public class AnafException : Exception
    {
        public AnafException() : base("Nu am putut prelua datele de la ANAF!")
        {

        }
    }
}