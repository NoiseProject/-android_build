# Copyright 2005 The Android Open Source Project
#
# Custom version of cp.

LOCAL_PATH:= $(call my-dir)
<<<<<<< HEAD
include $(CLEAR_VARS)
LOCAL_ADDITIONAL_DEPENDENCIES := $(LOCAL_PATH)/Android.mk
=======

include $(CLEAR_VARS)
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

LOCAL_SRC_FILES := \
    acp.c

<<<<<<< HEAD
ifeq ($(HOST_OS),cygwin)
LOCAL_CFLAGS += -DWIN32_EXE
endif
ifeq ($(HOST_OS),darwin)
LOCAL_CFLAGS += -DMACOSX_RSRC
endif
ifeq ($(HOST_OS),linux)
endif

LOCAL_STATIC_LIBRARIES := libhost
LOCAL_C_INCLUDES := build/libs/host/include
LOCAL_MODULE := acp
LOCAL_ACP_UNAVAILABLE := true
LOCAL_CXX_STL := none
LOCAL_ADDRESS_SANITIZER := false
=======
LOCAL_STATIC_LIBRARIES := libhost
LOCAL_MODULE := acp
LOCAL_ACP_UNAVAILABLE := true
LOCAL_CXX_STL := none
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

include $(BUILD_HOST_EXECUTABLE)
