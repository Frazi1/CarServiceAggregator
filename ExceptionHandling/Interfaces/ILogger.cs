﻿using System;

namespace ExceptionHandling
{
    public interface ILogger : IErrorHandler
    {
        void Log(Exception e);
    }
}