using System;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MultiProjects.Converters
{
    /// <summary>
    /// This class have methods to convert string to chat-message type.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class StringToMessageTypeConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the string to message type.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object messageType;
            var bindingContext = (parameter as Label)?.BindingContext;

            switch ((string)value)
            {
                case "Contact":
                    messageType = "John Deo Sync";
                    break;
                case "Text":                   
                    var message = bindingContext != null ? ((ChatDetail)bindingContext).Message : string.Empty;                    
                    messageType = message;
                    break;
                default:
                    messageType = (string)value;
                    break;
            }

            if (!string.IsNullOrEmpty((string)messageType) && ((ChatDetail)bindingContext).NotificationType == "New")
            {
                Application.Current.Resources.TryGetValue("Gray-900", out var returnColor);

                ((Label)parameter).FontFamily = Device.RuntimePlatform == Device.Android
                    ? "Montserrat-SemiBold.ttf#Montserrat-SemiBold"
                    : Device.RuntimePlatform == Device.iOS
                        ? "Montserrat-SemiBold"
                        : "Assets/Montserrat-SemiBold.ttf#Montserrat-SemiBold";

                ((Label)parameter).TextColor = (Color)returnColor;
            }
            else 
            {
                Application.Current.Resources.TryGetValue("Gray-600", out var returnColor);

                ((Label)parameter).FontFamily = Device.RuntimePlatform == Device.Android
                    ? "Montserrat-Medium.ttf#Montserrat-Medium"
                    : Device.RuntimePlatform == Device.iOS
                        ? "Montserrat-Medium"
                        : "Assets/Montserrat-Medium.ttf#Montserrat-Medium";

                ((Label)parameter).TextColor = (Color)returnColor;
            }
            
            return messageType;
        }

        /// <summary>
        /// This method is used to convert the string to message type.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns null.</returns>  
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [Preserve(AllMembers = true)]
    public class ChatDetail
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the message sent/received time.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the MessageType.
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the message sent/received notification type.
        /// </summary>
        public string NotificationType { get; set; }

        /// <summary>
        /// Gets or sets the recipient's available status.
        /// </summary>
        public string AvailableStatus { get; set; }

        #endregion
    }
}