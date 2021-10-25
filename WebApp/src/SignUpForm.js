import { Form, Input, Button } from 'antd';

const SignUpForm = ({ onSubmit }) => (
    <Form
        name="basic"
        labelCol={{
            span: 10,
        }}
        wrapperCol={{
            span: 16,
        }}
        onFinish={onSubmit}
        autoComplete="off"
    >
        <Form.Item
            label="Email"
            name="Email"
            rules={[
                {
                    required: true,
                    type: "email",
                    message: 'Please input your correct email!',
                },
            ]}
        >
            <Input />
        </Form.Item>

        <Form.Item
            label="Password"
            name="Password"
            rules={[
                {
                    required: true,
                    message: 'Please input your password!',
                },
            ]}
        >
            <Input.Password />
        </Form.Item>

        <Form.Item
            label="First name"
            name="FirstName"
            rules={[
                {
                    required: true,
                    message: 'Please input your first name!',
                },
            ]}
        >
            <Input />
        </Form.Item>

        <Form.Item
            label="Last name"
            name="LastName"
            rules={[
                {
                    required: true,
                    message: 'Please input your last name!',
                },
            ]}
        >
            <Input />
        </Form.Item>

        <Form.Item
            label="Phone number"
            name="PhoneNumber"
            rules={[
                {
                    required: true,
                    pattern: new RegExp(/^(\+?\d{1,20})$/g),
                    message: 'Please input your correct phone number!',
                }
            ]}
        >
            <Input />
        </Form.Item>

        <Form.Item
            label="Address"
            name="Address"
            rules={[
                {
                    required: true,
                    message: 'Please input your address!',
                },
            ]}
        >
            <Input />
        </Form.Item>

        <Form.Item
            wrapperCol={{
                offset: 8,
                span: 16,
            }}
        >
            <Button type="primary" htmlType="submit">
                Sign Up
            </Button>
        </Form.Item>
    </Form>
);

export default SignUpForm;