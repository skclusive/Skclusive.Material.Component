import { createPopper } from "../node_modules/@popperjs/core/dist/esm/popper.js";

class Tooltip
{
    constructor() {
        this.lastId = 0;
        this.instanceMap = new Map();
    }

    generateId() {
        return this.lastId++;
    }

    destroyPopper(id) {
        let popper = this.instanceMap.get(id);
        if (popper) {
            this.instanceMap.delete(id);
            popper.destroy();
        }
    }

    updatePopper(id) {
        let popper = this.instanceMap.get(id);
        if (popper) {
            popper.update();
        }
    }

    createBlazorPopper(reference, popper, options) {
        const instance = createPopper(reference, popper, options);

        let id = this.generateId();

        this.instanceMap.set(id, instance);

        let blazorInstance = {
            id: id,
            state: {
                placement: instance.state.placement,
                orderedModifiers: instance.state.orderedModifiers,
                options: instance.state.options,
                modifiersData: instance.state.modifiersData,
                //elements: instance.state.elements, // TypeError: Converting circular structure to JSON
                attributes: instance.state.attributes,
                styles: instance.state.styles,
                //scrollParents: instance.state.scrollParents, // TypeError: Converting circular structure to JSON
            },
            setOptions: instance.setOptions,
            forceUpdate: instance.forceUpdate,
            update: instance.update,
            destroy: instance.destroy
        };

        return blazorInstance;
    } 
}

window.Skclusive = {
    ...window.Skclusive,
    Material: {
        ...(window.Skclusive || {}).Material,
        Tooltip: new Tooltip()
    }
};
