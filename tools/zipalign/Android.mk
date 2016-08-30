# 
# Copyright 2008 The Android Open Source Project
#
# Zip alignment tool
#

LOCAL_PATH:= $(call my-dir)
include $(CLEAR_VARS)

LOCAL_SRC_FILES := \
	ZipAlign.cpp \
	ZipEntry.cpp \
	ZipFile.cpp

LOCAL_C_INCLUDES += external/zlib \
	external/zopfli/src

LOCAL_STATIC_LIBRARIES := \
	libandroidfw \
	libutils \
	libcutils \
	liblog \
	libzopfli

<<<<<<< HEAD
ifeq ($(HOST_OS),linux)
LOCAL_LDLIBS += -lrt
endif

ifdef USE_MINGW
LOCAL_STATIC_LIBRARIES += libz
else
LOCAL_LDLIBS += -lz
endif
=======
LOCAL_LDLIBS_linux += -lrt

LOCAL_STATIC_LIBRARIES_windows += libz
LOCAL_LDLIBS_linux += -lz
LOCAL_LDLIBS_darwin += -lz
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

ifneq ($(strip $(BUILD_HOST_static)),)
LOCAL_LDLIBS += -lpthread
endif # BUILD_HOST_static

LOCAL_MODULE := zipalign
<<<<<<< HEAD
=======
LOCAL_MODULE_HOST_OS := darwin linux windows
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

include $(BUILD_HOST_EXECUTABLE)
