LOCAL_PATH:= $(call my-dir)
include $(CLEAR_VARS)
<<<<<<< HEAD
LOCAL_ADDITIONAL_DEPENDENCIES := $(LOCAL_PATH)/Android.mk
=======
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

LOCAL_SRC_FILES:= \
    CopyFile.c

<<<<<<< HEAD
ifeq ($(HOST_OS),cygwin)
LOCAL_CFLAGS += -DWIN32_EXE
endif
ifeq ($(HOST_OS),darwin)
LOCAL_CFLAGS += -DMACOSX_RSRC
endif
ifeq ($(HOST_OS),linux)
endif

LOCAL_MODULE:= libhost
LOCAL_C_INCLUDES := $(LOCAL_PATH)/include
=======
LOCAL_CFLAGS := -Werror -Wall

LOCAL_MODULE:= libhost
LOCAL_MODULE_HOST_OS := darwin linux windows
LOCAL_C_INCLUDES := $(LOCAL_PATH)/include
LOCAL_EXPORT_C_INCLUDE_DIRS := $(LOCAL_PATH)/include
LOCAL_CXX_STL := none
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

# acp uses libhost, so we can't use
# acp to install libhost.
LOCAL_ACP_UNAVAILABLE:= true

<<<<<<< HEAD
LOCAL_ADDRESS_SANITIZER := false

=======
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
include $(BUILD_HOST_STATIC_LIBRARY)

# Include toolchain prebuilt modules if they exist.
-include $(TARGET_TOOLCHAIN_ROOT)/toolchain.mk
