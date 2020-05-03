using System;

namespace testProject
{
    public interface IBotServiceProvider : IServiceProvider, IDisposable
    {
        IBotServiceProvider CreateScope();
    }
}
