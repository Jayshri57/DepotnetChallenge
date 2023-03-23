using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringChallenge.Domain.Constants
{
    public static class Messages
    {
        public const string NOT_FOUND = "not found.";
        public const string FILE_NOT_FOUND = "file not found.";
        public const string PRODUCT_NOT_FOUND = "Product not found";
        public const string PRODUCT_ALREADY_DELETED = "Product already deleted";
        public const string REQUEST_INFORMATION_NOT_COMPLETE = "Request information is not complete.";
        public const string REQUEST_BODY_NOT_VALID = "Request body is not valid.";
        public const string REQUEST_BODY_EMPTY = "Request body is empty";
        public const string REQUEST_URL_NOT_VALID = "Request url is not valid.";
        public const string OUTDATED_DATA = "To prevent overwriting another user's change, we require that you only edit the latest data. Refreshing should resolve this.";
        public const string INVALID_REPORT_DATE = "Invalid reportDate in URL";
        public const string INVALID_FILE_FORMAT = "Invalid file format";
        public const string INVALID_FILE_NAME_FORMAT = "File name format is invalid.";
        public const string VALIDATION_NOT_MATCHED = "Validation not matched";
        public const string FAILED_WITH_APPLICATION_EXCEPTION_WITH_STATUS = "Failed with an ApplicationException with status";
       
        public const string ORDER_ALREADY_DELETED = "Order already deleted";
        public const string ALREADY_DELETED = "Already deleted.";

        public const string ORDER_VALIDATION_FAILED = "Order Validation failed";        
        public const string UNAUTHORIZED_USER = "User does not have access to this order or prdduct.";
        
        public const string CUSTOMER_VALIDATION_FAILED = "Customer Validation failed";
        public const string CUSTOMER_ALREADY_PRESENT = "Customer with same name is already present, please keep unique name.";
        public const string CUSTOMER_ALREADY_DELETED = "Customer already deleted";
               

        public const string ERROR_DURING_DOWNLOAD = "Error during download.";

        public const string SEND_VALID_TOKEN = "Please send valid authorization token.";
        public const string UNABLE_TO_FIND_USER = "Unable to find user information.";
     }
}
