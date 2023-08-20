using FluentValidation;
using Infrastructure.Model;
using Rediscuss.Business.CustomExceptions;

namespace Rediscuss.Business.Validators
{
	public class Validate<TEntity, TValidator> : IValidate<TEntity, TValidator> where
		TValidator : IValidator<TEntity>, new()
		
	{
		public void Valid(TEntity entity)
		{
			TValidator validator = new TValidator();

			var result = validator.Validate(entity);

			if (!result.IsValid)
			{
				throw new BadRequestException(result.ToString());
			}
		}	
	}
}
