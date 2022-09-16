

using EscuelaCore.Entidades;



    var escuela = new Escuela("Escuela Platzi", 2022, TipoEscuela.Secundaria,
                    pais: "Colombia", ciuddad: "Floridablanca");

    var arregloCursos = new Curso[]{
        new Curso{Nombre="101"},
        new Curso {Nombre="201"} ,
        new Curso {Nombre="301"} 
    };

    escuela.Cursos=arregloCursos;
   

    Console.WriteLine(escuela);
    Console.WriteLine("------------------------------------");
    ImprimirCursos(arregloCursos);
    ImprimirCursosEscuela(escuela);

void ImprimirCursosEscuela(Escuela escuela)
{
    Console.WriteLine("=====================");
    Console.WriteLine("Cursos de la Escuela");
    foreach (var curso in escuela.Cursos)
    {
        Console.WriteLine($"Nombre : {curso.Nombre}=>Id :{curso.UniqueId}" );
    }
}

void ImprimirCursos(Curso[] arregloCursos)
    {
        foreach (var item in escuela.Cursos)
        {
            Console.WriteLine($"Nombre : {item.Nombre}=>Id :{item.UniqueId}" );
        }
    }