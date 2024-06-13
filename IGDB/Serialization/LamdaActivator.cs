using System;
using System.Linq.Expressions;
using System.Reflection;

namespace IGDB.Serialization
{
  public delegate object ObjectActivator(params object[] args);

  /// <summary>
  /// See: https://rogerjohansson.blog/2008/02/28/linq-expressions-creating-objects/
  /// </summary>
  internal static class LambdaActivator
  {
    public static ObjectActivator GetActivator(ConstructorInfo ctor)
    {
      ParameterInfo[] paramsInfo = ctor.GetParameters();

      ParameterExpression param =
          Expression.Parameter(typeof(object[]), "args");

      Expression[] argsExp =
          new Expression[paramsInfo.Length];

      for (int i = 0; i < paramsInfo.Length; i++)
      {
        Expression index = Expression.Constant(i);
        Type paramType = paramsInfo[i].ParameterType;

        Expression paramAccessorExp =
            Expression.ArrayIndex(param, index);

        Expression paramCastExp =
            Expression.Convert(paramAccessorExp, paramType);

        argsExp[i] = paramCastExp;
      }

      NewExpression newExp = Expression.New(ctor, argsExp);

      LambdaExpression lambda =
          Expression.Lambda(typeof(ObjectActivator), newExp, param);

      ObjectActivator compiled = (ObjectActivator)lambda.Compile();
      return compiled;
    }
  }
}