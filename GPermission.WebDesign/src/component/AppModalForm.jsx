import React, { Component } from 'react';
import { Button, Modal } from 'antd';

class AppModalForm extends Component {
  render() {
    return (
      <Modal
        visible={this.props.modalVisable}
        title={this.props.modalModalTitle}
        onSubmit={this.props.handleSubmit}
        onCancel={this.props.handleCancel}
        footer={[
          <Button
            key="cancel"
            type="ghost"
            size="large"
            onClick={this.props.handleCancel}
          >
            取消
          </Button>,
          <Button
            key="submit"
            type="primary"
            size="large"
            loading={this.props.modalLoading}
            onClick={this.props.handleSubmit}
          >
            提交
          </Button>,
        ]}
      >
        {this.props.children}
      </Modal>
    );
  }
}

AppModalForm.propTypes = {
  children: React.PropTypes.element,
  modalVisable: React.PropTypes.bool,
  modalLoading: React.PropTypes.bool,
  modalModalTitle: React.PropTypes.string,
  handleSubmit: React.PropTypes.func,
  handleCancel: React.PropTypes.func,
};

export default AppModalForm;
