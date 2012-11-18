﻿#region Copyright
// Copyright (c) 2009 - 2010, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensions
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a class to store compare validation metadata.
    /// </summary>
    [TypeForwardedFrom(KnownAssembly.MvcExtensions)]
    public class CompareValidationMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the other property.
        /// </summary>
        /// <value>The pattern.</value>
        public string OtherProperty { get; set; }

        /// <summary>
        /// Creates validation attribute
        /// </summary>
        /// <returns>Instance of ValidationAttribute type</returns>
        protected override ValidationAttribute CreateValidationAttribute()
        {
            var attribute = new CompareAttribute(OtherProperty);
            PopulateErrorMessage(attribute);
            return attribute;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override ModelValidator CreateValidatorCore(ExtendedModelMetadata modelMetadata, ControllerContext context)
        {
            var validationAttribute = (CompareAttribute)CreateValidationAttribute();
            return new DataAnnotationsModelValidator<CompareAttribute>(modelMetadata, context, validationAttribute);
        }

    }
}