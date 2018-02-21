#Revision

* No os habeis cuidado de limpiar los namespaces que no se usan
* Las propiedades de las entidades se modifican solo por metodos. Algunas son get ; set;
* Faltan validaciones en todos los constructores de todos los objetos.
* Los VO son inmutables, sus propiedades son de solo lectura y si se modifica genera un objeto nuevo
* Los VO se comparan por valor. Os habeis olvidado de sobreescribir el Equals y de agregarle operadores de igualdad y desigual, y en algunos casos se podria tener operadores + y -, por ejemplo, unidad de peso
