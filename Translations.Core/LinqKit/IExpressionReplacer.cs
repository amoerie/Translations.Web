using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Translations.Core.LinqKit
{
    public interface IExpressionReplacer<in TExpression> where TExpression: Expression
    {
        bool ShouldReplace(TExpression expression);
        Expression GetReplacement(TExpression expression);
    }
}
