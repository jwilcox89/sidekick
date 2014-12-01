using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace sidekick
{
    public class FileUploadAttribute : ValidationAttribute
    {
        private UploadType   _type;
        private bool         _required;
        private List<string> _validExtensions;

        /// <summary>
        ///     Will validate the file exisits (if required) and if the file is in the correct format.
        /// </summary>
        /// <param name="type">The type of upload to validate (Multiple Photos, Single Photo, Audio, Video</param>
        /// <param name="required"></param>
        public FileUploadAttribute(UploadType type, List<string> validExtensions, bool required) {
            _type            = type;
            _required        = required;
            _validExtensions = validExtensions;
        }
        
        public override bool IsValid(object value) {

                switch (_type) {

                    case UploadType.Single_Photo:

                        var photo = value as HttpPostedFileBase;

                        if (_required && photo == null) {
                            ErrorMessage = "Please select at least one photo to upload!";
                            return false;
                        }

                        if (photo != null) {
                            string singlePhotoEx = Path.GetExtension(photo.FileName).ToLower();

                            if (_validExtensions.Where(x => x == singlePhotoEx).FirstOrDefault() == null) {

                                var validTypes = string.Join(", ", _validExtensions.Select(x => x));
                                ErrorMessage = string.Format("The file type {0} is not a valid file type. Please choose a valid audio file to upload. The valid types are {1}", singlePhotoEx, validTypes);
                                return false;
                            }
                        }

                        break;

                    case UploadType.Multiple_Photos:

                        var photos = value as HttpPostedFileBase[];

                        if (_required && photos[0] == null) {
                            ErrorMessage = "Please select at least one photo to upload!";
                            return false;
                        }

                        if (photos[0] != null) {
                            foreach (var p in photos) {

                                string photoEx = Path.GetExtension(p.FileName).ToLower();

                                if (_validExtensions.Where(x => x == photoEx).FirstOrDefault() == null) {
                                    var validTypes = string.Join(", ", _validExtensions.Select(x => x));
                                    ErrorMessage = string.Format("The file type {0} is not a valid file type. Please choose a valid photo to upload. The valid types are {1}.", photoEx, validTypes);
                                    return false;
                                }
                            }
                        }

                        break;

                    case UploadType.Audio:

                        var audio = value as HttpPostedFileBase;

                        if (_required && audio == null) {
                            ErrorMessage = "Please select an audio file to upload!";
                            return false;
                        }

                        if (audio != null) {
                            string audioEx = Path.GetExtension(audio.FileName).ToLower();

                            if (_validExtensions.Where(x => x == audioEx).FirstOrDefault() == null) {
                                var validTypes = string.Join(", ", _validExtensions.Select(x => x));
                                ErrorMessage = string.Format("The file type {0} is not a valid file type. Please choose a valid audio file to upload. The valid types are {1}", audioEx, validTypes);
                                return false;
                            }
                        }

                        break;

                    case UploadType.Video:

                        var video = value as HttpPostedFileBase;

                        if (_required && video == null) {
                            ErrorMessage = "Please select a video to upload!";
                            return false;
                        }

                        if (video != null) {
                            string videoEx = Path.GetExtension(video.FileName).ToLower();

                            if (_validExtensions.Where(x => x == videoEx).FirstOrDefault() == null) {

                                var validTypes = string.Join(", ", _validExtensions.Select(x => x));
                                ErrorMessage = string.Format("The file type {0} is not a valid file type. Please choose a different video to upload. The valid types are {1}", videoEx, validTypes);
                                return false;
                            }
                        }

                        break;
                }

            return true;
        }
    }
}
