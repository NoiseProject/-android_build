# Copyright 2007 The Android Open Source Project
#
# Copies files into the directory structure described by a manifest

LOCAL_PATH:= $(call my-dir)
include $(CLEAR_VARS)

LOCAL_SRC_FILES := \
	atree.cpp \
	files.cpp \
	fs.cpp

LOCAL_STATIC_LIBRARIES := \
	libhost
<<<<<<< HEAD
LOCAL_C_INCLUDES := build/libs/host/include
=======
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

LOCAL_MODULE := atree

include $(BUILD_HOST_EXECUTABLE)

