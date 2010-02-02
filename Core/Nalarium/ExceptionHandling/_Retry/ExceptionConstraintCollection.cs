#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
#region Reference
//+ http://www.netfxharmonics.com/2006/01/Constrainted-try-with-retry-mechanism
#endregion
using System;
using System.Collections.Generic;
//+
namespace Nalarium.ExceptionHandling
{
    /// <summary>
    /// For use with ExceptionRetry.
    /// </summary>
    public class ExceptionConstraintCollection : List<Object>
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionConstraintCollection"/> class.
        /// </summary>
        public ExceptionConstraintCollection()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionConstraintCollection"/> class.
        /// </summary>
        /// <param name="constraintSet">The constraint set.</param>
        public ExceptionConstraintCollection(params Object[] constraintSet)
        {
            for (Int32 n = 0; n < constraintSet.Length; n++)
            {
                this.Add(constraintSet[n]);
            }
        }
    }
}