## Explicación de la solución

Para resolver el problema primero pensé en la cantidad de consultas que podía haber y en que el rango podía llegar hasta 1,000,000, así que un enfoque ingenuo revisando cada número sería demasiado lento.

La estrategia que usé fue precomputar todos los números primos hasta 1,000,000 usando la **Criba de Eratóstenes**, que es un algoritmo muy eficiente para marcar los números compuestos y dejar los primos como verdaderos.

Una vez que tuve el arreglo `isPrime[]` con los valores `true` o `false` según si el número es primo o no, construí un **arreglo de prefijos** (`pref[]`) donde `pref[i]` indica cuántos primos hay desde 1 hasta i. Esto permite que cada consulta [L, R] se resuelva en **O(1)** con la fórmula:

