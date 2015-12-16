#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

#region Reference

//+ http://www.netfxharmonics.com/2006/01/Constrainted-try-with-retry-mechanism

#endregion

using System.Collections.Generic;

namespace Nalarium.ExceptionHandling.Retry
{
    /// <summary>
    ///     For use with ExceptionRetry.
    /// </summary>
    public class ExceptionConstraintCollection : List<object>
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExceptionConstraintCollection" /> class.
        /// </summary>
        public ExceptionConstraintCollection()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExceptionConstraintCollection" /> class.
        /// </summary>
        /// <param name="constraintSet">The constraint set.</param>
        public ExceptionConstraintCollection(params object[] constraintSet)
        {
            for (var n = 0; n < constraintSet.Length; n++)
            {
                Add(constraintSet[n]);
            }
        }
    }
}