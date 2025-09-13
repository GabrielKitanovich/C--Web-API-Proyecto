using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MandrilAPI.Helpers
{
    public static class Messages
    {
        public static class Mandril
        {
            public const string NotFound = "Mandril no encontrado";
            public const string Created = "Mandril creado exitosamente";
            public const string Updated = "Mandril actualizado exitosamente";
            public const string Deleted = "Mandril eliminado exitosamente";
        }

        public static class Habilidad
        {
            public const string NotFound = "Habilidad no encontrada";
            public const string AlreadyExists = "Habilidad ya existe";
            public const string Created = "Habilidad creada exitosamente";
            public const string Updated = "Habilidad actualizada exitosamente";
        }
    }
}