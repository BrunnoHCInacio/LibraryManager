using FluentValidation;
using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Business.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

    
        protected bool RunValidation<TValidation, TEntity>(TValidation validation, TEntity entity) where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;
            foreach (var error in validator.Errors)
            {
                Notify(error.ErrorMessage);
            }
            return false;
        }

    }
}
