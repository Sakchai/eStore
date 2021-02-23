﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Nop.Core.Domain.Common;

namespace Nop.Services.Common
{
    /// <summary>
    /// Address attribute parser interface
    /// </summary>
    public partial interface IAddressAttributeParser
    {
        /// <summary>
        /// Gets selected address attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected address attributes</returns>
        Task<IList<AddressAttribute>> ParseAddressAttributesAsync(string attributesXml);

        /// <summary>
        /// Get address attribute values
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Address attribute values</returns>
        Task<IList<AddressAttributeValue>> ParseAddressAttributeValuesAsync(string attributesXml);

        //TODO: migrate to an extension method
        /// <summary>
        /// Gets selected address attribute value
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="addressAttributeId">Address attribute identifier</param>
        /// <returns>Address attribute value</returns>
        IList<string> ParseValues(string attributesXml, int addressAttributeId);

        //TODO: migrate to an extension method
        /// <summary>
        /// Adds an attribute
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="attribute">Address attribute</param>
        /// <param name="value">Value</param>
        /// <returns>Attributes</returns>
        string AddAddressAttribute(string attributesXml, AddressAttribute attribute, string value);

        /// <summary>
        /// Validates address attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Warnings</returns>
        Task<IList<string>> GetAttributeWarningsAsync(string attributesXml);

        /// <summary>
        /// Get custom address attributes from the passed form
        /// </summary>
        /// <param name="form">Form values</param>
        /// <returns>Attributes in XML format</returns>
        Task<string> ParseCustomAddressAttributesAsync(IFormCollection form);
    }
}