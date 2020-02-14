using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CST.Common.Utils.StateMachineFeature
{
    public class StateMachineFeatureProvider<TKey> : IApplicationFeatureProvider<ControllerFeature> 
        where TKey : struct, IEquatable<TKey>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            feature.Controllers.Add(typeof(StateMachineController<TKey>).GetTypeInfo());
        }
    }
}