namespace Common.SharedKernel.Domain;

public class NoResult
    {
        private static readonly NoResult _instance = new NoResult();
        private NoResult() { }
        // Método estático para obtener la instancia única de NoResult
        public static NoResult Instance => _instance;
    }
