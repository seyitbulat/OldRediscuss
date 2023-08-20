using Infrastructure.Model;

namespace Rediscuss.Business.Validators
{
	public interface IValidate<TEntity, TValidator>  
	
	{
		void Valid(TEntity entity);
	}
}
