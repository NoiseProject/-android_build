# Install jni libraries for one arch.
# Input variables:
#   my_2nd_arch_prefix: indicate if this is for TARGET_2ND_ARCH.
#   my_embed_jni: indicate if we want to embed the jni libs in the apk.
#   my_prebuilt_jni_libs
#   my_installed_module_stem (from configure_module_stem.mk)
#   partition_tag (from base_rules.mk)
#   my_prebuilt_src_file (from prebuilt_internal.mk)
#
# Output variables:
#   my_jni_shared_libraries, my_jni_shared_libraries_abi, if we are going to embed the libraries into the apk;
#   my_embedded_prebuilt_jni_libs, prebuilt jni libs embedded in prebuilt apk.
#

my_jni_shared_libraries := \
    $(addprefix $($(my_2nd_arch_prefix)TARGET_OUT_INTERMEDIATE_LIBRARIES)/, \
      $(addsuffix .so, \
          $(LOCAL_JNI_SHARED_LIBRARIES)))

# App-specific lib path.
my_app_lib_path := $(dir $(LOCAL_INSTALLED_MODULE))lib/$(TARGET_$(my_2nd_arch_prefix)ARCH)
my_embedded_prebuilt_jni_libs :=

ifdef my_embed_jni
# App explicitly requires the prebuilt NDK stl shared libraies.
# The NDK stl shared libraries should never go to the system image.
ifneq ($(filter $(LOCAL_NDK_STL_VARIANT), stlport_shared c++_shared),)
ifndef LOCAL_SDK_VERSION
$(error LOCAL_SDK_VERSION must be defined with LOCAL_NDK_STL_VARIANT, \
    LOCAL_PACKAGE_NAME=$(LOCAL_PACKAGE_NAME))
endif
endif
ifeq (stlport_shared,$(LOCAL_NDK_STL_VARIANT))
my_jni_shared_libraries += \
    $(HISTORICAL_NDK_VERSIONS_ROOT)/current/sources/cxx-stl/stlport/libs/$(TARGET_$(my_2nd_arch_prefix)CPU_ABI)/libstlport_shared.so
else ifeq (c++_shared,$(LOCAL_NDK_STL_VARIANT))
my_jni_shared_libraries += \
    $(HISTORICAL_NDK_VERSIONS_ROOT)/current/sources/cxx-stl/llvm-libc++/libs/$(TARGET_$(my_2nd_arch_prefix)CPU_ABI)/libc++_shared.so
endif

# Set the abi directory used by the local JNI shared libraries.
# (Doesn't change how the local shared libraries are compiled, just
# sets where they are stored in the apk.)
ifeq ($(LOCAL_JNI_SHARED_LIBRARIES_ABI),)
    my_jni_shared_libraries_abi := $(TARGET_$(my_2nd_arch_prefix)CPU_ABI)
else
    my_jni_shared_libraries_abi := $(LOCAL_JNI_SHARED_LIBRARIES_ABI)
endif

else  # not my_embed_jni

my_jni_shared_libraries := $(strip $(my_jni_shared_libraries))
ifneq ($(my_jni_shared_libraries),)
# The jni libaries will be installed to the system.img.
my_jni_filenames := $(notdir $(my_jni_shared_libraries))
# Make sure the JNI libraries get installed
my_shared_library_path := $($(my_2nd_arch_prefix)TARGET_OUT$(partition_tag)_SHARED_LIBRARIES)
<<<<<<< HEAD
$(LOCAL_INSTALLED_MODULE) : | $(addprefix $(my_shared_library_path)/, $(my_jni_filenames))
=======
# Do not use order-only dependency, because we want to rebuild the image if an jni is updated.
$(LOCAL_INSTALLED_MODULE) : $(addprefix $(my_shared_library_path)/, $(my_jni_filenames))
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

# Create symlink in the app specific lib path
ifdef LOCAL_POST_INSTALL_CMD
# Add a shell command separator
LOCAL_POST_INSTALL_CMD += ;
endif

my_symlink_target_dir := $(patsubst $(PRODUCT_OUT)%,%,\
    $(my_shared_library_path))
LOCAL_POST_INSTALL_CMD += \
  mkdir -p $(my_app_lib_path) \
  $(foreach lib, $(my_jni_filenames), ;ln -sf $(my_symlink_target_dir)/$(lib) $(my_app_lib_path)/$(lib))
$(LOCAL_INSTALLED_MODULE): PRIVATE_POST_INSTALL_CMD := $(LOCAL_POST_INSTALL_CMD)

# Clear jni_shared_libraries to not embed it into the apk.
my_jni_shared_libraries :=
endif  # $(my_jni_shared_libraries) not empty
endif  # my_embed_jni

ifdef my_prebuilt_jni_libs
# Files like @lib/<abi>/libfoo.so (path inside the apk) are JNI libs embedded prebuilt apk;
# Files like path/to/libfoo.so (path relative to LOCAL_PATH) are prebuilts in the source tree.
my_embedded_prebuilt_jni_libs := $(patsubst @%,%, \
    $(filter @%, $(my_prebuilt_jni_libs)))

# prebuilt JNI exsiting as separate source files.
my_prebuilt_jni_libs := $(addprefix $(LOCAL_PATH)/, \
    $(filter-out @%, $(my_prebuilt_jni_libs)))
ifdef my_prebuilt_jni_libs
ifdef my_embed_jni
# Embed my_prebuilt_jni_libs to the apk
my_jni_shared_libraries += $(my_prebuilt_jni_libs)
else # not my_embed_jni
# Install my_prebuilt_jni_libs as separate files.
$(foreach lib, $(my_prebuilt_jni_libs), \
    $(eval $(call copy-one-file, $(lib), $(my_app_lib_path)/$(notdir $(lib)))))

<<<<<<< HEAD
$(LOCAL_INSTALLED_MODULE) : | $(addprefix $(my_app_lib_path)/, $(notdir $(my_prebuilt_jni_libs)))
=======
$(LOCAL_INSTALLED_MODULE) : $(addprefix $(my_app_lib_path)/, $(notdir $(my_prebuilt_jni_libs)))
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
endif  # my_embed_jni
endif  # inner my_prebuilt_jni_libs
endif  # outer my_prebuilt_jni_libs
