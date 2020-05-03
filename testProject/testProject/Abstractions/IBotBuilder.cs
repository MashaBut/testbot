﻿using System;

namespace testProject
{
    public interface IBotBuilder
    {
        IBotBuilder Use(Func<UpdateDelegate, UpdateDelegate> middleware);

        IBotBuilder Use(Func<IUpdateContext, UpdateDelegate> component);

        IBotBuilder Use<THandler>()
            where THandler : IUpdateHandler;

        IBotBuilder Use<THandler>(THandler handler)
            where THandler : IUpdateHandler;

        UpdateDelegate Build();
    }
}
