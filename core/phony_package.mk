ifneq ($(strip $(LOCAL_SRC_FILES)),)
$(error LOCAL_SRC_FILES are not allowed for phony packages)
endif

LOCAL_MODULE_CLASS := FAKE
LOCAL_MODULE_SUFFIX := -timestamp

include $(BUILD_SYSTEM)/base_rules.mk

<<<<<<< HEAD
$(LOCAL_BUILT_MODULE): $(LOCAL_MODULE_MAKEFILE) $(LOCAL_ADDITIONAL_DEPENDENCIES)
=======
$(LOCAL_BUILT_MODULE): $(LOCAL_MODULE_MAKEFILE_DEP) $(LOCAL_ADDITIONAL_DEPENDENCIES)
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
	$(hide) echo "Fake: $@"
	$(hide) mkdir -p $(dir $@)
	$(hide) touch $@
