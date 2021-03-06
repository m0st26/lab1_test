﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace parkWiFis.DomainObjects.Ports
{
    public interface ICriteria<T> where T : DomainObject
    {
        Expression<Func<T, bool>> Filter { get; }
    }
}
