using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Foundation.Core.StateMachineFeature
{
    public class StateMachineControllerNameConvention<TKey, TSubject> : IControllerModelConvention
        where TKey : struct, IEquatable<TKey>
    {
        private readonly string _controllerName;

        public StateMachineControllerNameConvention(string controllerName)
        {
            _controllerName = controllerName;
        }
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType != typeof(StateMachineController<TKey, TSubject>)) return;

            controller.Selectors.Clear();
            controller.Selectors.Add(new SelectorModel
            {
                AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"/api/{_controllerName}"))
            });
        }
    }
}
