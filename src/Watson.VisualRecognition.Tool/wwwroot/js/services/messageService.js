utils.service('message', function (toastr, t) {
    this.success = function (message, title) {
        var msg = this.build(message, title);
        toastr.success(msg.message, msg.title);
    },
    this.error = function (message, title) {
        var msg = this.build(message, title);
        toastr.error(msg.message, msg.title);
    },
    this.warning = function (message, title) {
        var msg = this.build(message, title);
        toastr.warning(msg.message, msg.title);
    },
    this.build = function (message, title) {
        var content = "";
        if (message == null) {
        } else if (Array.isArray(message)) {
            content = message.join("\n");
        } else if (typeof message == 'object') {
            if (message.message) {
                content = message.message;
            } else if (message.data) {
                if (typeof message.data == "string") {
                    content = message.data;
                } else if (Array.isArray(message.data)) {
                    content = message.data.join("\n");
                }
            }
        } else {
            content = message;
        }
        title = this.format(title);
        content = this.format(content);
        return {
            title: title,
            message: content
        }
    },
    this.format = function (input) {
        if (input != null) {
            var matches = input.match(/{{(.*?)}}/g);
            if (matches) {
                matches.forEach(val => {
                    var key = val.replace(/[{}]*/g, "");
                    input = input.replace(val, t.translate(key));
                });
            }
        }
        return input;
    }
});