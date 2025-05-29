using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class MiTestSencillo
{
    // Un test de Play Mode que no hace mucho, solo espera un frame
    [UnityTest]
    public IEnumerator MiPrimerTestDeIntegracionSimple()
    {
        // Puedes agregar lógica de test más compleja aquí
        // Por ejemplo, verificar si un GameObject existe, si un componente tiene ciertos valores, etc.
        UnityEngine.Debug.Log("Ejecutando MiPrimerTestDeIntegracionSimple...");
        yield return null; // Espera un frame
        Assert.Pass("Test simple completado exitosamente.");
    }
}