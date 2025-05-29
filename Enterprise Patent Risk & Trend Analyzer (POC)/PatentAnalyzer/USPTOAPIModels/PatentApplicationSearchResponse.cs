// USPTOApiModels/PatentApplicationSearchResponse.cs

using System;
using System.Collections.Generic;

namespace PatentAnalyzer.USPTOApiModels
{
    // The top-level response structure
    public class PatentApplicationSearchResponse
    {
        public int Count { get; set; } // Total number of records matching the criteria
        public List<PatentFileWrapperDataBag>? PatentFileWrapperDataBag { get; set; } = new List<PatentFileWrapperDataBag>();
        // Add other top-level properties if the API response has them (e.g., pagination info)
    }

    // Corresponds to 'PatentFileWrapperDataBag' in the API response
    public class PatentFileWrapperDataBag
    {
            public ApplicationMetaData? ApplicationMetaData { get; set; }
    public List<CpcClassificationBag>? CpcClassificationBag { get; set; }
    public List<ApplicantBag>? ApplicantBag { get; set; }
    public List<InventorBag>? InventorBag { get; set; }
    public List<AssignmentBag>? AssignmentBag { get; set; }

    // --- These were the missing types that caused errors, now defined in the same file ---
    public List<ForeignPriorityBag>? ForeignPriorityBag { get; set; }
    public List<ParentContinuityBag>? ParentContinuityBag { get; set; }
    public List<ChildContinuityBag>? ChildContinuityBag { get; set; }
    public PatentTermAdjustmentData? PatentTermAdjustmentData { get; set; }
    public List<EventDataBag>? EventDataBag { get; set; }
    public PgpubDocumentMetaData? PgpubDocumentMetaData { get; set; }
    public GrantDocumentMetaData? GrantDocumentMetaData { get; set; }
    // --- End of previously missing types ---

    public DateTime? LastIngestionDateTime { get; set; }
    public string? ApplicationNumberText { get; set; } // The actual application number
    public string? InventionTitle { get; set; }
    public string? PatentNumber { get; set; } // If it's a granted patent
    public string? ApplicationStatusDescriptionText { get; set; }
    public DateTime? FilingDate { get; set; }
    public DateTime? GrantDate { get; set; } // Nullable if not granted

    // --- YOU NEED TO ADD THESE PROPERTIES AS WELL ---
    // These were part of the original schema you provided and are used in the mapping.
    public DateTime? EarliestPublicationDate { get; set; } // <--- THIS IS THE ONE CAUSING THE CURRENT ERROR!
    public DateTime? EffectiveFilingDate { get; set; }
    public string? GroupArtUnitNumber { get; set; }
    public string? ApplicationTypeCode { get; set; }
    public string? ApplicationTypeLabelName { get; set; }
    public string? ApplicationTypeCategory { get; set; }
    public string? PatentNumberText { get; set; }
    public string? ApplicationStatusCode { get; set; }
    public string? BusinessEntityStatusCategory { get; set; }
    public string? EarliestPublicationNumber { get; set; }
    public string? PctPublicationNumber { get; set; }
    public DateTime? PctPublicationDate { get; set; }
    // --- END OF PROPERTIES TO ADD ---

    public string? AbstractText { get; set; } // Adding this placeholder based on common API responses, check actual schema
    public List<string>? ClaimText { get; set; } // Adding this placeholder, check actual schema
    // ... add other direct properties from the response as needed
    }

    // Existing and necessary definitions:

    public class ApplicationMetaData
    {
        public string? FirstInventorToFileIndicator { get; set; }
        public bool? NationalStageIndicator { get; set; }
        // Add any other properties from ApplicationMetaData here based on the schema
    }

    public class CpcClassificationBag
    {
        public string? CpcSymbol { get; set; } // Example property, check actual schema
        // Add other CPC properties here based on the schema
    }

    public class ApplicantBag
    {
        public string? ApplicantNameText { get; set; }
        public CorrespondenceAddressBag? CorrespondenceAddressBag { get; set; } // Nested type
        // Add any other properties from ApplicantBag here based on the schema
    }

    public class InventorBag
    {
        public string? InventorNameText { get; set; }
        public CorrespondenceAddressBag? CorrespondenceAddressBag { get; set; } // Nested type
        // Add any other properties from InventorBag here based on the schema
    }

    public class AssignmentBag
    {
        public string? ConveyanceText { get; set; }
        public List<AssignorBag>? AssignorBag { get; set; } // Nested type
        public List<AssigneeBag>? AssigneeBag { get; set; } // Nested type
        // Add any other properties from AssignmentBag here based on the schema
    }

    public class AssigneeBag
    {
        public string? AssigneeNameText { get; set; }
        public AssigneeAddress? AssigneeAddress { get; set; } // Nested type
        // Add any other properties from AssigneeBag here based on the schema
    }

    public class AssigneeAddress
    {
        public string? AddressLineOneText { get; set; }
        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        public string? PostalCode { get; set; }
        // Add any other properties from AssigneeAddress here based on the schema
    }

    // --- NEWLY ADDED MINIMAL CLASS DEFINITIONS TO FIX COMPILATION ERRORS ---
    // You will need to fill these out with actual properties based on the USPTO API's JSON Schema/Swagger UI.

    public class ForeignPriorityBag
    {
        public string? IpOfficeName { get; set; } // Example property
        // Add more properties as per USPTO schema
    }

    public class ParentContinuityBag
    {
        public string? ParentApplicationNumberText { get; set; } // Example property
        // Add more properties as per USPTO schema
    }

    public class ChildContinuityBag
    {
        public string? ChildApplicationNumberText { get; set; } // Example property
        // Add more properties as per USPTO schema
    }

    public class PatentTermAdjustmentData
    {
        public int? AdjustmentTotalQuantity { get; set; } // Example property
        // Add more properties as per USPTO schema
    }

    public class EventDataBag
    {
        public string? EventCode { get; set; } // Example property
        // Add more properties as per USPTO schema
    }

    public class PgpubDocumentMetaData
    {
        public string? XmlFileName { get; set; } // Example property
        // Add more properties as per USPTO schema
    }

    public class GrantDocumentMetaData
    {
        public string? XmlFileName { get; set; } // Example property
        // Add more properties as per USPTO schema
    }

    public class AssignorBag
    {
        public string? AssignorName { get; set; } // Example property
        // Add more properties as per USPTO schema
    }

    public class CorrespondenceAddressBag
    {
        public string? NameLineOneText { get; set; }
        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        // Add other properties as per USPTO schema
    }

    // You might also need to define classes for:
    // PatentTermAdjustmentHistoryDataBag (nested within PatentTermAdjustmentData)
    // and any other deeper nested structures.
    // The key is that for every class that's referenced, its definition must exist.
}