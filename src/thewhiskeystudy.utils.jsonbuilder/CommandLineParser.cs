using System;

namespace thewhiskeystudy.utils.jsonbuilder
{
    public static class CommandLineParser
    {
        public static T ParserArgs<T>(string[] args)
        {
            var parsedType = typeof(T);

            var parsedObject = (T)Activator.CreateInstance(parsedType);
            
            for (var x = 0; x < args.Length; x+=2)
            {
                var propertyInfo = parsedType.GetProperty(args[x]);

                // Property doesn't exist in the parser class
                if (propertyInfo == null)
                {
                    continue;
                }

                propertyInfo.SetValue(parsedObject, Convert.ChangeType(args[x + 1], propertyInfo.PropertyType), null);
            }

            return parsedObject;
        }
    }
}