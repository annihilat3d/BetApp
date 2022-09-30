using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Common.Constants
{
    public static class ErrorMessageConstant
    {
        public const string CloseRouletteError = "La ruleta esta cerrada";
        public const string CreatedRouletteError = "La ruleta ya fue cerrada con anterioridad";
        public const string NotFoundRouletteError = "La ruleta con el id {0} no existe";
        public const string BetNumberError = "El numero apostado es invalido, por favor ingrese un numero entre el 0 y {0}";
        public const string BetColorError = "El color apostado es invalido, por favor ingrese el color Rojo o Negro";
        public const string BetMoneyError = "El dinero apostado es invalido, el dinero maximo para apostar es {0}";
    }
}
